#include <z64.h>
#include "Misc.h"
#include "Sprite.h"

#define StCtxt (*(StaticContext*)(0x803824D0))

typedef struct {
    f32 tileColumn[88];
} MazeEntryColumn; //8 x 11 grid

typedef struct {
    u8 tileDisplayState[11]; //bitpacked flags for tile display on minimap
    u8 spoilerState; // Reveal the maze tiles when bumped (0) or spoil the maze (1)
} MazeDisplayStruct; //size = 0x0C

static MazeDisplayStruct gMazeFogStruct;


void ChestGame_ResetMap() {
    for (int i = 0; i < 11; i++) {
        gMazeFogStruct.tileDisplayState[i] = 0;
    }
    // Could use something other than Giant's Mask (maybe an event flag?) as the second spoiler requirement
    if (MISC_CONFIG.flags.chestGameMinimap == CHESTGAME_MINIMAP_SPOILER ||
        ((MISC_CONFIG.flags.chestGameMinimap == CHESTGAME_MINIMAP_CONDITIONAL) && (gSaveContext.perm.inv.masks[SLOT_GIANT_MASK] == ITEM_GIANT_MASK))) {
        gMazeFogStruct.spoilerState = 1;
        }
    else {
        gMazeFogStruct.spoilerState = 0;
    }
}

void ChestGame_DrawMap(GlobalContext* ctxt, Actor* actor, MazeEntryColumn* maze) {

    if (MISC_CONFIG.flags.chestGameMinimap == CHESTGAME_MINIMAP_OFF) {
        return;
    }

    if (!(gSaveContext.perm.minimapBitfield[1] & 0x80)) {
        return;
    }

    if (ctxt->interfaceCtx.alphas.minimap == 0) {
        return;
    }

    if (StCtxt.minimapToggle) { //1 = off
        return;
    }

    DispBuf* db = &ctxt->state.gfxCtx->overlay;
    db->p = db->buf;

    gSPDisplayList(db->p++, &gSetupDb);
    gDPSetCombineLERP(db->p++, 1, 0, PRIMITIVE, 0, 1, 0, PRIMITIVE, 0,
                                 1, 0, PRIMITIVE, 0, 1, 0, PRIMITIVE, 0);
    gDPSetPrimColor(db->p++, 0, 0, 0x00, 0xFF, 0xFF, 0x9F);

    int drawLeft = SCREEN_WIDTH - 110;
    int drawUpper = SCREEN_HEIGHT - 66;
    int mazeTile = 5;

    for (int c = 0; c < 0xB; c++) {

        for (int r = 0; r < 0x8; r++) {
            f32 mazeTileState;
            u8 ActiveTile = ((c * 0x08) + r);
            mazeTileState = maze->tileColumn[ActiveTile];

            u8 tileFogLookup = ((ActiveTile & 0xF8) >> 3);
            u8 tileFogState = (gMazeFogStruct.tileDisplayState[tileFogLookup]);
            u8 tileFogBitflag = (tileFogState & (1 << (ActiveTile & 0x07)));


            if (((gMazeFogStruct.spoilerState == 1) && (mazeTileState > -1)) || (mazeTileState > 0)) {
                tileFogState = ((1 << (ActiveTile & 0x07)) | tileFogState);
                gMazeFogStruct.tileDisplayState[tileFogLookup] = tileFogState;
            }

            if (tileFogBitflag != 0) {
                gSPTextureRectangle(db->p++,
                ((drawLeft + (c * mazeTile)) << 2), ((drawUpper + (r * mazeTile)) << 2),
                (((drawLeft + (c * mazeTile)) + mazeTile) << 2), (((drawUpper + (r * mazeTile)) + mazeTile) << 2),
                0,
                0, 0,
                1 << 10, 1 << 10);
            }
        }
    }
}
